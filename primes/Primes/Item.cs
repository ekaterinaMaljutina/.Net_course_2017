using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primes
{
    public partial class Item : UserControl
    {
        private readonly System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        private readonly int _value;
        private readonly Task _task;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        private int _currentProgress;
        private int _result;

        public Item(int value)
        {
            InitializeComponent();

            _value = value;
            _initField();
            _initProgressBar();

            _task = new Task(() =>
            {
                _result = GetPrimeNumber(_value);
            });
            _task.Start();
        }

        public void Stop() => _cancellationTokenSource.Cancel();
        

        private void Item_Load(object sender, EventArgs e)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                StateLabel.Text = TaskStatus.Canceled.ToString();
                CancelButtom.Visible = false;
            }
            else
            {
                _switchTaskState();
            }
        }

        private void _initTimer()
        {
            _timer.Interval = 1;
            _timer.Tick += Item_Load;
            _timer.Start();
        }

        private void _initProgressBar() => _currentProgress = ProgressBarItem.Value = 1;
       

        private void _initField()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            ValueTextBox.Text = _value.ToString();
            ProgressBarItem.Maximum = _value + 1;
            _initTimer();
        }

        private int GetPrimeNumber(int value)
        {
            var count = 0;
            for (var i = 1; i <= value; i++)
            {
                var isPrime = true;
                for (var j = 2; j <= Math.Sqrt(i); ++j)
                {
                    if (_cancellationToken.IsCancellationRequested)
                    {
                        return count;
                    }
                    if (i % j != 0) 
                    {
                        continue;
                    }
                    isPrime = false;
                    break;
                }
                if (isPrime)
                {
                    ++count;
                }
                ++_currentProgress;
            }
            return count;
        }

        private void CancelButtom_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource == null)
            {
                return;
            }
            _cancellationTokenSource.Cancel();
            ProgressBarItem.Value = ProgressBarItem.Maximum;
            StateLabel.Text = TaskStatus.Canceled.ToString();
            CancelButtom.Visible = false;
        }

        private void _switchTaskState()
        {
            if (_task.Status == TaskStatus.RanToCompletion)
            {
                StateLabel.Text = @"Finish";
                ProgressBarItem.Visible = CancelButtom.Visible = false;
                ValueTextBox.Text += @"   result = " + _result;
                _timer.Stop();
            }
            if (_task.Status == TaskStatus.Running || _task.Status == TaskStatus.WaitingToRun)
            {
                ProgressBarItem.Value = _currentProgress;
                StateLabel.Text = _task.Status.ToString();
            }
        }
    }
}
