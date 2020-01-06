using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1.Matrices.Utils
{
    public class MatrixFileSerializer
    {
        private IFormatter _formatter;

        public string Source { get; set; }

        public MatrixFileSerializer(string source)
        {
            _formatter = new BinaryFormatter();
            Source = source;
        }

        public MatrixFileSerializer(string source, IFormatter formatter)
        {
            Source = source;
            _formatter = formatter;
        }

        public bool Serialize(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new NullReferenceException("Matrix == null");
            }

            using (var fs = new FileStream(Source, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, matrix);
            }

            return true;
        }

        public Matrix Deserialize()
        {
            using (var fs = new FileStream(Source, FileMode.Open))
            {
                return (Matrix)_formatter.Deserialize(fs);
            }
        }
    }
}