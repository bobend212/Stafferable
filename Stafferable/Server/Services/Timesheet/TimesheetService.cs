﻿using Microsoft.EntityFrameworkCore;
using Stafferable.Server.Data;
using Stafferable.Shared;
using Stafferable.Shared.Timesheet;
using System.Globalization;

namespace Stafferable.Server.Services.Timesheet
{
    public class TimesheetService : ITimesheetService
    {
        private readonly ApplicationDbContext _context;

        public TimesheetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TimesheetCard>>> GetTimesheetCardsByLoggedUser(int userId)
        {
            var response = new ServiceResponse<List<TimesheetCard>>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            var timesheets = await _context.TimesheetCards
                .Include(x => x.TimesheetRecords)
                .Where(u => u.UserId == userId)
                .OrderByDescending(x => x.StartDate)
                .ToListAsync();

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (timesheets.Count < 1)
            {
                response.Success = false;
                response.Message = $"No Timesheet Cards for user {user.FName} {user.LName}";
            }
            else
            {
                response.Data = timesheets;
                response.Message = $"Timesheet Cards found for user {user.FName} {user.LName}";
            }

            return response;
        }

        public async Task<ServiceResponse<TimesheetCard>> GetSingleCard(Guid cardId)
        {
            var card = await _context.TimesheetCards.FindAsync(cardId);
            if (card == null)
            {
                return new ServiceResponse<TimesheetCard>
                {
                    Success = false,
                    Message = "Card not found."
                };
            }

            return new ServiceResponse<TimesheetCard> { Data = card, Message = "Card Found." };
        }

        public async Task<ServiceResponse<TimesheetCard>> PostTimesheetCard(TimesheetCard model)
        {
            if (await TimesheetExist(model.UserId, model.StartDate, model.EndDate))
            {
                return new ServiceResponse<TimesheetCard>
                {
                    Success = false,
                    Message = "Timesheet already exist."
                };
            }

            _context.TimesheetCards.Add(model);
            await _context.SaveChangesAsync();

            return new ServiceResponse<TimesheetCard> { Data = model, Message = "Timesheet Card created!" };
        }

        private async Task<bool> TimesheetExist(int userId, DateTime? startDate, DateTime? endDate)
        {
            if (await _context.TimesheetCards.Where(user => user.UserId == userId).Where(s => s.StartDate == startDate).Where(e => e.EndDate == endDate).AnyAsync())
                return true;
            return false;
        }

        public async Task<ServiceResponse<bool>> DeleteTimesheetCard(Guid cardId)
        {
            var findCard = await _context.TimesheetCards.FindAsync(cardId);
            if (findCard == null)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Data = false,
                    Message = "Card not found."
                };
            }

            _context.TimesheetCards.Remove(findCard);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Message = "Card Deleted", Data = true };
        }

        public async Task<ServiceResponse<List<TimesheetRecord>>> GetTimesheetRecordsByCard(Guid CardId)
        {
            var response = new ServiceResponse<List<TimesheetRecord>>();
            var findCard = await _context.TimesheetCards.FirstOrDefaultAsync(x => x.TimesheetCardId == CardId);
            var records = await _context.TimesheetRecords.Where(u => u.TimesheetCardId == CardId)
                .OrderBy(x => x.WeekNo)
                .ThenBy(x => x.Date)
                .ToListAsync();

            if (findCard == null)
            {
                response.Success = false;
                response.Message = "Timesheet Card not found.";
            }
            else if (records.Count < 1)
            {
                response.Success = false;
                response.Message = $"No Timesheet Records for Card: {findCard.CustomName}";
            }
            else
            {
                response.Data = records;
                response.Message = $"Timesheet Records found for Card: {findCard.CustomName}";
            }

            return response;
        }

        public async Task<ServiceResponse<TimesheetRecord>> PostTimesheetRecord(TimesheetRecord model)
        {
            model.WeekNo = GetWeekNumber(model.Date);

            TimesheetCard findCard = await _context.TimesheetCards.FirstOrDefaultAsync(x => x.TimesheetCardId == model.TimesheetCardId);
            findCard.TotalHours += model.Time;

            _context.TimesheetRecords.Add(model);
            await _context.SaveChangesAsync();
            return new ServiceResponse<TimesheetRecord> { Data = model, Message = "Timesheet Record created!" };
        }

        private static int GetWeekNumber(DateTime? dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear((DateTime)dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public async Task<ServiceResponse<bool>> DeleteTimesheetRecord(Guid recordId)
        {
            var findRecord = await _context.TimesheetRecords.FindAsync(recordId);
            if (findRecord == null)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Data = false,
                    Message = "Record not found."
                };
            }

            TimesheetCard findCard = await _context.TimesheetCards.FirstOrDefaultAsync(x => x.TimesheetCardId == findRecord.TimesheetCardId);
            findCard.TotalHours -= findRecord.Time;

            _context.TimesheetRecords.Remove(findRecord);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Message = "Record Removed", Data = true };
        }

        public async Task<ServiceResponse<bool>> UpdateTimesheetRecord(TimesheetRecordUpdate model)
        {
            var findRecord = await _context.TimesheetRecords.FindAsync(model.RecordId);
            if (findRecord == null)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false,
                    Message = "Record not found."
                };
            }

            findRecord.WeekNo = GetWeekNumber(model.Date);
            findRecord.Date = model.Date;
            findRecord.Type = model.Type;
            findRecord.Project = model.Project;

            TimesheetCard findCard = await _context.TimesheetCards.FirstOrDefaultAsync(x => x.TimesheetCardId == findRecord.TimesheetCardId);
            findCard.TotalHours -= findRecord.Time;
            findRecord.Time = model.Time;
            findCard.TotalHours += model.Time;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Message = "Record Updated", Data = true };
        }
    }
}