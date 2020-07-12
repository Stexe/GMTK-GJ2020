using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Signs : MonoBehaviour
{
    [Serializable]
    public class SizePair
    {
        public SizeType type;
        public Sprite sprite;
    }

    [Serializable]
    public class ColorPair
    {
        public ColorType type;
        public Sprite sprite;
    }

    [Serializable]
    public class ShapePair
    {
        public ShapeType type;
        public Sprite sprite;
    }


    [Serializable]
    public class MaterialPair
    {
        public MaterialType type;
        public Sprite sprite;
    }

    public ColorPair[] colorPairing;
    public MaterialPair[] materialPairing;
    public ShapePair[] shapePairing;
    public SizePair[] sizePairing;

    private GameObject color;
    private GameObject material;
    private GameObject shape;
    private GameObject size;

    private void Start()
    {
        DeliveryZone.onNewOrder.AddListener(OnNewOrder);

        foreach (Transform child in transform)
        {
            var obj = child.gameObject;
            switch (obj.name)
            {
                case "Sign_Color":
                    color = child.gameObject;
                    break;
                case "Sign_Material":
                    material = child.gameObject;
                    break;
                case "Sign_Shape":
                    shape = child.gameObject;
                    break;
                case "Sign_Size":
                    size = child.gameObject;
                    break;
            }
        }
    }

    public void OnNewOrder(Order order)
    {
        color.GetComponent<SpriteRenderer>().sprite = colorPairing.Single(cp => cp.type == order.colorGoal).sprite;
        material.GetComponent<SpriteRenderer>().sprite = materialPairing.Single(cp => cp.type == order.materialGoal).sprite;
        shape.GetComponent<SpriteRenderer>().sprite = shapePairing.Single(cp => cp.type == order.shapeGoal).sprite;
        size.GetComponent<SpriteRenderer>().sprite = sizePairing.Single(cp => cp.type == order.sizeGoal).sprite;
    }
}
