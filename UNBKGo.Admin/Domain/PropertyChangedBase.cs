using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UNBKGo.Admin.Annotations;

namespace UNBKGo.Admin.Domain
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Refresh()
        {
            OnPropertyChanged(string.Empty);
        }

        protected virtual void OnPropertyChanged<TProperty>([NotNull] Expression<Func<TProperty>> property)
        {
            var member = (MemberExpression)property.Body;
            OnPropertyChanged(member.Member.Name);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
