using AutoMapper;
using MediatR;
using TableTennis4dView.Application.DTOs;
using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Command;
using TableTennis4dView.Core.Repositories.Query;

namespace TableTennis4dView.Application.Commands.Customers.Update
{
    // Customer create command with CustomerResponse
    public class EditCustomerCommand : IRequest<CustomerResponse>
    {

        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }

    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        private readonly IMapper _mapper;
        public EditCustomerCommandHandler(ICustomerCommandRepository customerRepository, ICustomerQueryRepository customerQueryRepository, IMapper mapper)
        {
            _customerCommandRepository = customerRepository;
            _customerQueryRepository = customerQueryRepository;
            _mapper = mapper;
        }
        public async Task<CustomerResponse> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Customer>(request);

            if (customerEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _customerCommandRepository.UpdateAsync(customerEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedCustomer = await _customerQueryRepository.GetByIdAsync(request.Id);
            var customerResponse = _mapper.Map<CustomerResponse>(modifiedCustomer);

            return customerResponse;
        }
    }
}
