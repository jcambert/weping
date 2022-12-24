using System;
using Volo.Abp;
using Volo.Abp.ExceptionHandling;

namespace WePing.PointCalculator;

public class CalculatorException : BusinessException
{
	private const string ECART = "ecart";
	public CalculatorException(string code):base(code)
	{
		
	}

	public static CalculatorException Ecart(double ecart)=>(new CalculatorException(ECART).WithData("ecart",ecart)) as CalculatorException;
}
