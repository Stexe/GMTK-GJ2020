using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface Triggerable
    {
        void SetMaterial(MaterialType type);
        void SetShape(ShapeType type);
        void SetSize(SizeType type);
        MaterialType GetMaterialType();
        ShapeType GetShapeType();
    }
}
