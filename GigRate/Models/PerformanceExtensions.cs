﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigRate.Models
{
    public partial class Performance
    {
        public string FriendlyName
        {
            get
            {
                return string.Format("{0} - {1}", this.EventInstanceStage.FriendlyName, this.Act.Name);
            }
        }
    }
}