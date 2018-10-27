using System.Collections.Generic;

namespace Demons
{
    public interface IPhrase
    {
        string Demon { get; }
        string Content { get; }
        List<IDemon> SinsRelated { get; }
    }
}