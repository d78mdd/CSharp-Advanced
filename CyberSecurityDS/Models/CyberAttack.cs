using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Utilities.Messages;

namespace CyberSecurityDS.Models
{
    public abstract class CyberAttack : ICyberAttack
    {
        public string AttackName { get; }

        public int SeverityLevel { get; }

        public bool Status { get; private set; }

        protected CyberAttack(string attackName, int severityLevel)
        {
            if (string.IsNullOrWhiteSpace(attackName))
                throw new ArgumentException(ExceptionMessages.CyberAttackNameRequired);

            if (severityLevel < 0)
                throw new ArgumentException(ExceptionMessages.SeverityLevelNegative);

            AttackName = attackName;

            SeverityLevel = Math.Min(10, (Math.Max(1, severityLevel)));
        }


        public void MarkAsMitigated()
        {
            this.Status = true;
        }


        public override string ToString() => $"Attack: {AttackName}, Severity: {SeverityLevel}";
    }
}
