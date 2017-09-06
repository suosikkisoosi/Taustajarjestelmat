using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viikko2 {

    public interface IRepository<T> {

        Task<bool> Add (T item);

        Task<bool> Delete (Guid id);

        Task<T[]> GetAll ();

        Task<T> GetWithGuid (Guid id);
    }

}
