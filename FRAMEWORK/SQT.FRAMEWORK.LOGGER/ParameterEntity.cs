using System;
using System.Collections.Generic;
using System.Text;

namespace SQT.FRAMEWORK.LOGGER
{
	/// <summary>
	/// Parameter object holding information about a methods parameter.
	/// </summary>
	/// <remarks>
	///     
	/// </remarks>
	public class ParameterEntity
    {
		#region Private Attributes
			private string _name;
			private string _type;
			private object _value;
		#endregion

		#region Public Constructors

			/// <summary>
			/// Default Constructor.
			/// Initializes a new instance of the <see cref="ParameterEntity"/> class.
			/// </summary>
			public ParameterEntity()
			{

			}

			/// <summary>
			/// This is the second Constructor with 3 parameters.
			/// Initializes a new instance of the <see cref="ParameterEntity"/> class.
			/// </summary>
			/// <param name="name" type="string">The Name</param>
			/// <param name="type" type="string">The Type</param>
			/// <param name="value" type="object">The Value</param>
			public ParameterEntity(string name, string type, object value)
			{
				this._name = name;
				this._type = type;
				this._value = value;
			} 
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the Name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		/// <summary>
		/// Gets or sets the Type.
		/// </summary>
		/// <value>The type.</value>
		public string Type
		{
			get { return this._type; }
			set { this._type = value; }
		}

		/// <summary>
		/// Gets or sets the Value.
		/// </summary>
		/// <value>The value.</value>
		public object Value
		{
			get { return this._value; }
			set { this._value = value; }
		}
		
		#endregion

		#region Public Override Methods
		
		/// <summary>
		/// Override method for ToString. It returns a string containing the Parameter Name, Type and Value.
		/// </summary>
		/// <returns>
		///     Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
		/// </returns>
		public override string ToString()
        {
            return "Name: " + this.Name.Trim() + ", Type: " + this.Type + ", Value: " + this.Value;
        }
 
		#endregion    
	}
}
