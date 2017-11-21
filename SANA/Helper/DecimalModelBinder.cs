
namespace SANA.Helper
{
	using System;
	using System.Globalization;
	using System.Web.Mvc;

	//Taken from https://haacked.com/archive/2011/03/19/fixing-binding-to-decimals.aspx
	/// <summary>
	/// Dividing the result by 100 to get this worked.
	/// </summary>
	public class DecimalModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext,
			ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider
				.GetValue(bindingContext.ModelName);
			ModelState modelState = new ModelState { Value = valueResult };
			object actualValue = null;
			try
			{
				actualValue = Convert.ToDecimal(valueResult.AttemptedValue,
					CultureInfo.CurrentCulture) / 100M;
			}
			catch (FormatException e)
			{
				modelState.Errors.Add(e);
			}

			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
			return actualValue;
		}
	}
}