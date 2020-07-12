using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface Triggerable
{
    void SetColor(ColorType type);
    void SetMaterial(MaterialType type);
    void SetShape(ShapeType type);
    void SetSize(SizeType type);
    ColorType GetColorType();
    MaterialType GetMaterialType();
    ShapeType GetShapeType();
}
