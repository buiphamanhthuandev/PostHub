﻿using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Contacts
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(int id);
        Task<int> GetCount();
    }
}
