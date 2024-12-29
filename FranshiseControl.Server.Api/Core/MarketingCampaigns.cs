﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public class MarketingCampaigns
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public float Budget { get; set; }
    public long EstablishmentId { get; set; }
}
