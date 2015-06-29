using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.DataAccess.Context;

namespace Wiskunde_App.DataAccess.UOW
{
    public class UOW : IUOW
    {
        private WiskundeContext context = null;
        public UOW(WiskundeContext context){
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}