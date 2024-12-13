using PostHub.Areas.Admin.Repositories.ManagerRepository;
using PostHub.Areas.Admin.ViewModels.ContactViewModels;
using PostHub.TagHelpers;
namespace PostHub.Areas.Admin.Services.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IManagerRepositoy _managerRepositoy;
        public ContactService(IManagerRepositoy managerRepositoy)
        {
            _managerRepositoy = managerRepositoy;
        }

        public async Task<ContactViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            var resultPages = await _managerRepositoy.Contact.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges);
            var resultCounts = await _managerRepositoy.Contact.GetCountAsync(nameSearch, trackChanges);
            var result = new ContactViewModel
            {
                Contacts = resultPages,
                NameSearch = nameSearch,
                PagingInfo = new PagingInfo
                {
                    TotalItems = resultCounts,
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                }
            };
            return result;
        }
        public async Task<bool> EditStateAsync(int id, bool trackChanges)
        {
            try
            {
                var contact = await _managerRepositoy.Contact.GetByIdAsync(id, trackChanges);
                if (contact != null)
                {
                    contact.StateRes = contact.StateRes == 1 ? 0 : 1;
                    _managerRepositoy.Contact.UpdateAsync(contact);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id, bool trackChanges)
        {
            try
            {
                var contact = await _managerRepositoy.Contact.GetByIdAsync(id, trackChanges);
                if (contact != null)
                {
                    _managerRepositoy.Contact.DeleteAsync(contact);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
