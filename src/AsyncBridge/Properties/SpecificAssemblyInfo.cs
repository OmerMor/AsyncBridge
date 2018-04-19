using System.Security;

#if !NET35 && !PORTABLE
[assembly: AllowPartiallyTrustedCallers]
[assembly: SecurityRules(SecurityRuleSet.Level2)]
#endif