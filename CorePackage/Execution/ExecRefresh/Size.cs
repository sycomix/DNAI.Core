﻿using CorePackage.Entity;
using System.Collections.Generic;

namespace CorePackage.Execution
{
    /// <summary>
    /// Retrieves the size of a collection.
    /// </summary>
    public class Size : ExecutionRefreshInstruction
    {
        /// <summary>
        /// Type contained in the list
        /// </summary>
        private DataType _containerType = Entity.Type.Scalar.Integer;

        /// <summary>
        /// The type of the container.
        /// </summary>
        public DataType ContainerType
        {
            get { return _containerType; }
            set
            {
                GetInput("array").Value.definition.Type = new Entity.Type.ListType(value);
                _containerType = value;
            }
        }

        /// <summary>
        /// Basic default constructor that add a list 'array' input and an integer 'count' output
        /// </summary>
        public Size() : base(
            new Dictionary<string, Variable>
            {
                {
                    "array",
                    new Variable(new Entity.Type.ListType(Entity.Type.Scalar.Integer))
                }
            },
            new Dictionary<string, Variable>
            {
                {
                    "count",
                    new Variable(Entity.Type.Scalar.Integer)
                }
            })
        {

        }

        /// <summary>
        /// Will update the count output in function of the given list size
        /// </summary>
        public override void Execute()
        {
            outputs["count"].Value.definition.Value = inputs["array"].Value.definition.Value.Count;
        }
    }
}