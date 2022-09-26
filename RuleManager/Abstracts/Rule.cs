using RuleManager.Interfaces;

namespace RuleManager.Abstracts;

public abstract class Rule<TParameter>:IRule<TParameter>
{
    public abstract bool  Run(TParameter param);
    public IRule<TParameter>? PositiveCaseRule { get; set; }
    public IRule<TParameter>? NegativeCaseRule { get; set; }

    public Rule<TParameter> UseRule(Func<Rule<TParameter>,Rule<TParameter>> rule)
    {
        return rule.Invoke(this);
    }

    public Rule<TParameter> UseRule(Action<Rule<TParameter>> rule)
    {
         rule.Invoke(this);
         return this;
    }

    public Rule<TParameter> SetPositiveCaseRule(Rule<TParameter> rule)
    {
        this.PositiveCaseRule = rule;
        return rule;
    }
    public Rule<TParameter> SetPositiveCaseRule<TRule>()
        where TRule:Rule<TParameter>,new()
    {
        var rule = new TRule();
        this.PositiveCaseRule = rule;
        return rule;
    }
    public Rule<TParameter> SetNegativeCaseRule(Rule<TParameter> rule)
    {
        this.NegativeCaseRule = rule;
        return rule;
    }
    
    public Rule<TParameter> SetNegativeCaseRule<TRule>()
        where TRule:Rule<TParameter>,new()
    {
        var rule = new TRule();
        this.NegativeCaseRule = rule;
        return rule;
    }
}