using RubikCube.Core.Extensions;
using RubikCube.Domain.RubikCube;

namespace RubikCube.Application.Models;
public class CubeSideViewModel
{
    public ICollection<CubeFaceletViewModel> Facelets { get; set; } = [];

    public CubeSideViewModel()
    { }

    public CubeSideViewModel(CubeSide cubeSide)
    {
        var facelets = cubeSide.Facelets.ExtractData();

        Facelets = facelets.Select(f => new CubeFaceletViewModel
        {
            Row = f.Key.Item1,
            Column = f.Key.Item2,
            Color = f.Value.ToString()
        }).ToList();
    }
}
