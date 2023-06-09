﻿namespace JMXFileEditor.Silkroad.Mathematics
{
    /// <summary>
    /// Represents a rotation in 3D space
    /// </summary>
    public class Quaternion
    {
        #region Public Properties
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }
        #endregion

        #region Constructor
        public Quaternion()
        {
        }
        public Quaternion(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }
        #endregion
    }
}