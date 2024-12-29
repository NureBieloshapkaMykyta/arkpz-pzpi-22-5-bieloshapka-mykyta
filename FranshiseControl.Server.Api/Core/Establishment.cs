using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public class Establishment
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required DateTime OpenDate { get; set; }
    public required EntablishmentStatus Status { get; set; }
    public required DateTime LastAudit {  get; set; }
    public required long FranshiseId { get; set; }
    public required long AppUserId { get; set; }
}
