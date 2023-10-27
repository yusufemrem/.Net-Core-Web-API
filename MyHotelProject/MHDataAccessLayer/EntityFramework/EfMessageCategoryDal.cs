using MHDataAccessLayer.Abstract;
using MHDataAccessLayer.Concrete;
using MHDataAccessLayer.Repository;
using MHEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDataAccessLayer.EntityFramework
{
    public class EfMessageCategoryDal : GenericRepository<MessageCategory>, IMessageCategoryDal
    {
        public EfMessageCategoryDal(Context context) : base(context)
        {

        }
    }
}
