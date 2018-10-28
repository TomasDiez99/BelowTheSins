using UnityEngine;
using UnityEngine.UI;

namespace Demons
{
    public interface IDemonParsed
    {
        Image HaloOut { get; }
        string Sin { get; }
        float Health { get; set; }
        Image HaloIn { get; set; }
    }
}