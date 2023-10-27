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
    public class EfSendMessageDal : GenericRepository<SendMessage>, ISendMessageDal
    {
        public EfSendMessageDal(Context context) : base(context)
        {

        }
    }
}
