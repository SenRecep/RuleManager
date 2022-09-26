namespace RuleManager.Interfaces;

public interface IRule<TParameter>
{
    bool Run(TParameter param);
    IRule<TParameter>? PositiveCaseRule { get; set; }
    IRule<TParameter>? NegativeCaseRule { get; set; }
}