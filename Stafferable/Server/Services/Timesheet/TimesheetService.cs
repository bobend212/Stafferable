﻿using Microsoft.EntityFrameworkCore;
using Stafferable.Server.Data;
using Stafferable.Shared;
using Stafferable.Shared.Timesheet;

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
                .Where(u => u.UserId == userId).ToListAsync();

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
            _context.TimesheetCards.Add(model);
            await _context.SaveChangesAsync();

            return new ServiceResponse<TimesheetCard> { Data = model, Message = "Timesheet Card created!" };
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
    }
}