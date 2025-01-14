﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackage.Execution
{
    /// <summary>
    /// Class that represents a binary operator that have 2 inputs and 1 output
    /// </summary>
    public class BinaryOperator : Operator
    {
        /// <summary>
        /// Constructor that need inputs and outputs type, and the operation to execute
        /// </summary>
        /// <param name="lOpType">Type of the left operand</param>
        /// <param name="rOpType">Type of the right operand</param>
        /// <param name="operation">Operation to execute</param>
        /// <param name="resultType">Type of the returned value</param>
        public BinaryOperator(Entity.DataType lOpType, Entity.DataType rOpType, Func<dynamic, dynamic, dynamic> operation, Entity.DataType resultType, bool outreference = false) : base(resultType, operation, outreference)
        {
            AddInput(Global.Operator.Left, new Entity.Variable(lOpType), true);
            AddInput(Global.Operator.Right, new Entity.Variable(rOpType), true);
        }

        /// <summary>
        /// Invoke the operation with correct input values
        /// </summary>
        public override void Execute()
        {
            SetOutputValue(Global.Operator.Result, this.operation.DynamicInvoke(GetInputValue(Global.Operator.Left), GetInputValue(Global.Operator.Right)));
        }
    }
}
;