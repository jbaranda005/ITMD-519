using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MortgageHelperLibrary;
namespace Project1.Pages
{
    public class MortgageModel : PageModel
    {
        public string MortgageResult { get; set; } = "";
        [BindProperty]
        [Required]
        public double? LoanValue { get; set; } = 0;
        [BindProperty]
        [Required]
        public double? InterestValue { get; set; } = 0;
        [BindProperty]
        [Required]
        public double? DurationValue { get; set; } = 0;
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
            
                MortgageResult = $"The montly payment is {MortgageCalcHelper.ComputeMonthlyPayment(LoanValue.Value, DurationValue.Value, InterestValue.Value)} $ for a loan of {LoanValue.Value} $ for {DurationValue.Value} years and an interest rate of {InterestValue.Value} %.";
            }
            else
            {
                if (String.IsNullOrEmpty(ModelState["LoanValue"].AttemptedValue) || String.IsNullOrEmpty(ModelState["InterestValue"].AttemptedValue) || String.IsNullOrEmpty(ModelState["DurationValue"].AttemptedValue) || String.IsNullOrWhiteSpace(ModelState["LoanValue"].AttemptedValue) || String.IsNullOrWhiteSpace(ModelState["DurationValue"].AttemptedValue) || String.IsNullOrWhiteSpace(ModelState["InterestValue"].AttemptedValue))
                {
                    MortgageResult = "Blank is not valid";
                }
                else
                {
                    MortgageResult = "Some of the values entered are not valid, try again.";
                }
                
            }
        }
    }
}
