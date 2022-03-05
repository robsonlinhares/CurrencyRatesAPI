using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Models;
using CurrencyRates.Infraestructure.Data;

namespace CurrencyRates.Infraestructure.Repositories
{
    public class CurrencyTransactionRepository : Repository<CurrencyTransaction>, ICurrencyTransactionRepository
    {
        public CurrencyTransactionRepository(DataBaseContext dataBaseContext): base(dataBaseContext)
        {

        }
    }
}
