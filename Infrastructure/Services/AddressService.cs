using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;

    public async Task<AddressEntity> CreateAddressAsync(string addressline1, string postalCode, string city, string userId)
    {
		try
		{
			var existingAddress = await _addressRepository.GetOneAsync(x => x.AddressLine1 == addressline1 && x.PostalCode == postalCode && x.City == city && x.UserId == userId);
			if (existingAddress == null)
			{
				
				var newAddress = new AddressEntity 
				{ 
					AddressLine1 = addressline1,
					PostalCode = postalCode,
					City = city,
					UserId = userId
				};
				await _addressRepository.CreateAsync(newAddress);
				return newAddress;
			}

            return existingAddress;
        }
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		return null!;
    }

	public async Task<AddressEntity> GetAddressAsync(string userId)
	{
		try
		{
			var result = await _addressRepository.GetOneAsync(x => x.UserId == userId);
			if (result != null)
				return result;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		return null!;
	}

	public async Task<bool> UpdateAddressAsync(AddressEntity addressEntity)
	{
		try
		{
			var existingAddress = await _addressRepository.UpdateAsync(x => x.UserId == addressEntity.UserId, addressEntity);
			if (existingAddress != null)
			{
				return true;
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		return false;
	}

    public async Task<bool> DeleteAddressAsync(string userId)
    {
        try
        {
			var result = await _addressRepository.GetOneAsync(x => x.UserId == userId);
            if (result != null)
			{
                await _addressRepository.DeleteAsync(x => x.UserId == userId);
                return true;
            }
				
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return false!;
    }
}
