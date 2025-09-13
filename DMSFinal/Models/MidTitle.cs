using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Attributes;

namespace DMSFinal.Model.BasicData
{
    [MiddleTable]
    public class MidTitle : TopBasePoco
    {
        public PersonInfo PersonInfo { get; set; }
        public Guid PersonInfoId { get; set; }


        public TitleName TitleName { get; set; }
        public Guid TitleNameId { get; set; }

     
    }
}
