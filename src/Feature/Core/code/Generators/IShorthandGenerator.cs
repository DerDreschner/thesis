namespace SitecoreUrlShorter.Feature.Core.Generators {
    public interface IShorthandGenerator {
        string GenerateShorthand(int length, string pattern);
    }
}