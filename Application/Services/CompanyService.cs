using Application.Commands;
using Application.DTOs;
using Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CompanyService
    {
        private readonly IMediator _mediator;
        private readonly DbContext _context;
        

        public CompanyService(IMediator mediator, DbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<Guid> CreateCompany(CreateCompanyCommand companyCommand)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var companyId = await _mediator.Send(companyCommand);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                
                return companyId;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw; 
            }
        }

        public async Task<CompanyDTO> FindById(GetCompanyQuery getCompanyQuery)
        {
            return await _mediator.Send(getCompanyQuery);
        }
    }
}