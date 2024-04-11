using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ContactService(ContactRepository contactRepository, ServiceRepository serviceRepository)
{
    private readonly ContactRepository _contactRepository = contactRepository;
    private readonly ServiceRepository _serviceRepository = serviceRepository;

    public async Task<ContactEntity> CreateContactServiceAsync(ContactReqistrationModel contactReqistrationModel)
    {
        try
        {
            var existingContact = await _contactRepository.GetOneAsync(x => x.EmailAddress == contactReqistrationModel.EmailAddress);
            if (existingContact == null)
            {
                var newContact = new ContactEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = contactReqistrationModel.FullName,
                    EmailAddress = contactReqistrationModel.EmailAddress,
                    Message = contactReqistrationModel.Message
                };

                // Sparar den nya kontakten i databasen
                await _contactRepository.CreateAsync(newContact);

                // Skapar en ny tjänst baserat på användarens val och sparar den i databasen
                var newService = new ServiceEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Order = contactReqistrationModel.SelectedService == "Order",
                    Support = contactReqistrationModel.SelectedService == "Support",
                    ContactId = newContact.Id
                };
                await _serviceRepository.CreateAsync(newService);

                // Uppdaterar den nya kontakten med den skapade tjänsten
                newContact.ServiceId = newService.Id;
                newContact.Service = newService;
                await _contactRepository.UpdateAsync(x => x.Id == newContact.Id, newContact);

                return newContact;
            }
            else
            {
                return existingContact;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }


    public async Task<IEnumerable<ContactEntity>> GetAllContactAsync()
	{
		try
		{
			var existingContact = await _contactRepository.GetAllAsync();
			if (existingContact != null) 
			{
				return existingContact;
			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
        return null!;
    }

	public async Task<ContactEntity> GetOneContactAsync(string email)
	{
		try
		{
            var existingContact = await _contactRepository.GetOneAsync(x => x.EmailAddress == email);
            if (existingContact != null)
            {
                return existingContact;
            }
        }
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return null!;
	}
}
