﻿using JMXFileEditor.Silkroad.Mathematics;

namespace JMXFileEditor.ViewModels.Silkroad.Mathematics
{
    /// <summary>
    /// ViewModel representing Bounding Box
    /// </summary>
    public class BoundingBoxVM : JMXStructure
    {
        #region Constructor
        public BoundingBoxVM(string Name, BoundingBoxF BBox) : base(Name, true)
        {
            Childs.Add(new Vector3VM("Min", BBox.Min));
            Childs.Add(new Vector3VM("Max", BBox.Max));
        }
        #endregion

        #region Public Methods
        public override object GetClassFrom(JMXStructure Structure)
        {
            BoundingBoxF bbox = new BoundingBoxF
            {
                Min = (Vector3)((Vector3VM)Structure.Childs[0]).GetClass(),
                Max = (Vector3)((Vector3VM)Structure.Childs[1]).GetClass()
            };
            return bbox;
        }
        #endregion
    }
}