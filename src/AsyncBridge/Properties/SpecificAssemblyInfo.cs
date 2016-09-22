using System.Security;

#if !NET35
[assembly: AllowPartiallyTrustedCallers]
#if !PORTABLE
[assembly: SecurityRules(SecurityRuleSet.Level2)]
#endif
#endif