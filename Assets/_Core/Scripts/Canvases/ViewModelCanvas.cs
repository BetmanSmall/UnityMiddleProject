using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class ViewModelCanvas : MonoBehaviour, INotifyPropertyChanged
{
    private string _health = "0";

    public event PropertyChangedEventHandler PropertyChanged;

    [Binding]
    public string Health
    {
        get => _health;
        set
        {
            Debug.Log("ViewModelCanvas::Health; -- value: " + value);
            if (_health.Equals(value)) return;
            _health = value;
            OnPropertyChanged("Health");
        }
    }

    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
