using UnityEngine;
using UnityEngine.UI;

namespace Demons
{
    public interface IDemonParsed
    {
        Image Halo { get; }
        string Sin { get; }
        float Health { get; set; }
    }
}