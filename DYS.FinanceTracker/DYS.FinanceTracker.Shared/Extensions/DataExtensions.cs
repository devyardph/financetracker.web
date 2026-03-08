using DYS.FinanceTracker.Shared.Dtos;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace DYS.FinanceTracker.Shared.Extensions
{
    public static class DataExtensions
    {
        #region COMMON
        public static List<SelectDto> GetSuggestions(this List<SelectDto> options, string? comment = "")
        {
            var output = new List<SelectDto>();
            var suggestions = !string.IsNullOrEmpty(comment) ?
                comment.TextStartsWith("@") :
                new List<string>();

            if (suggestions.HasAny())
            {
                foreach (var suggestion in suggestions.Distinct())
                {
                    var id = suggestion.TrimStart('@');
                    var option = options.FirstOrDefault(query => query.Id.Contains(id, StringComparison.OrdinalIgnoreCase));
                    if (option != null) output.Add(option);
                }
            }
            return output;
        }
        public static SelectDto? GetSelectedOption(this List<SelectDto> options, string? option = "") => options.FirstOrDefault(query => query.Name == option || query.Id == option?.ToLower());
        public static ErrorDto GetError(this List<ErrorDto> errors, string field) => errors.FirstOrDefault(query => query.Field == field) ?? new ErrorDto();
        public static List<SelectDto> ChangeSuggestions(this List<SelectDto> options, SelectDto option)
        {
            foreach (var item in options)
            {
                if (item.Id == option.Id)
                {
                    item.Description = option.Description;
                    item.Details = option.Details;
                    item.Name = option.Name;
                    item.DisplayName = option.DisplayName;
                }
            }
            return options;
        }
        public static string GetSelectedName(this List<SelectDto> options, string? option = "") => options?.FirstOrDefault(query => query.Id == option)?.Name ?? string.Empty;
        public static string GetSelectedNames(this List<SelectDto> options, List<string> selectedItems)
        {
            var output = new List<string>();
            foreach (var selectedItem in selectedItems)
            {
                var option = GetSelectedName(options, selectedItem);
                output.Add(option);
            }
            return string.Join(", ", output);
        }

        public static List<ErrorDto> GetErrors(this Collection<ValidationResult> result)
        {
            var errors = new List<ErrorDto>();
            foreach (var item in result)
            {
                var error = new ErrorDto()
                {
                    Field = item.MemberNames.FirstOrDefault() ?? string.Empty,
                    ErrorMessage = item?.ErrorMessage ?? string.Empty,
                    Style = "is-invalid"
                };
                errors.Add(error);
            }
            return errors;
        }
        #endregion

        #region TRANSACTION
        public static bool IsInvalidTransaction(TransactionDto transaction, bool isBusy) {
            if (isBusy || 
                transaction.Amount <= 0 ||
                transaction.Amount == null ||
                string.IsNullOrEmpty(transaction.Category) ||
                string.IsNullOrEmpty(transaction.Recurrence) ||
                transaction.EffectiveDate == null) return true;
            return false;
        }

        public static bool IsInvalidAccount(AccountDto account, bool isBusy)
        {
            if (isBusy ||
                account.Amount <= 0 ||
                account.Amount == null ||
                string.IsNullOrEmpty(account.Name) ||
                string.IsNullOrEmpty(account.Type)) return true;
            return false;
        }
        #endregion
    }
}
