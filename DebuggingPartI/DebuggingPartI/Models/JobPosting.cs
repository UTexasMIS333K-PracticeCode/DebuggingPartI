//add using directive for the data annotations
using System.ComponentModel.DataAnnotations;

namespace DebuggingPartI.Models
{
      public class JobPosting
    {
        //create a named constant for number of months
        //named constants cannot be changed while the code is running
        public const Int32 NUMBER_OF_MONTHS = 12; //this company runs all 12 months

        //create a unique identifier for the job posting
        [Display(Name = "Job Posting ID:")]
        [Required(ErrorMessage = "An ID is required for each job posting")]
        public Int32 JobPostingID { get; set; }

        //create a unique identifier for the job posting
        [Display(Name = "Months:")]
        public Int32 Months { get; set; }

        //create a name for the job posting
        [Display(Name = "Job Posting Name:")]
        [Required(ErrorMessage = "Please enter a name for this job posting")]
        public String JobPostingName { get; set; }

       
        //create a property for the monthly salary
        [Display(Name = "Monthly Salary:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(ErrorMessage = "Monthly salary is required!")]
        [Range(1500, 1000000, ErrorMessage = "Monthly salary must be between $1,500 and $1,000,000")]
        public Decimal MonthlySalary { get; set; }

        
        //create a property for the annual bonus
        [Display(Name = "Annual Bonus:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(ErrorMessage = "Annual bonus is required!")]
        [Range(0, 15000000, ErrorMessage = "Annual bonus must be between $0 and $15,000,000")]
        public Decimal AnnualBonus { get; set; }
        
        
        //create a property for the AnnualSalary
        [Display(Name = "Annual Salary:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        //you do not need the "Required" annotation because
        //this is a calculated property
        //the private set is here because this property is read-only
        public Decimal AnnualSalary { get; private set; }

        //this is the other way to calculate a value that depends on other
        //properties.  This technique will calculate the value every time that
        //TotalSalary is referenced. This is best for simple or volatile calculations
        //TODO 06A: Add the "virtual" keyword to this property so that it can be overridden
        [Display(Name = "Total Annual Compensation:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal TotalAnnualCompensation { get; set; }

        //this is one way to calculate a value that depends on other
        //properties.  This technique will calculate the and store the value into
        //a separate method.  This method only needs to be called once
        public void CalculateCompensation()
        {
            //multiply the monthly salary by the number of months
            try
            {
                AnnualSalary = MonthlySalary * Months;
                TotalAnnualCompensation = AnnualBonus + AnnualBonus;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error with the calcs!", ex);
            }
        }

        
    }
}
