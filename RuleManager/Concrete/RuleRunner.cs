using RuleManager.Interfaces;

namespace RuleManager.Concrete;

public static class RuleRunner
{
    public static bool Run<TParameter>(IRule<TParameter> rule,TParameter parameter)
    {
        var result = rule.Run(parameter);
        return result switch
        {
            true when rule.PositiveCaseRule is not null => Run(rule.PositiveCaseRule, parameter),
            false when rule.NegativeCaseRule is not null => Run(rule.NegativeCaseRule, parameter),
            _ => result
        };
    }
}