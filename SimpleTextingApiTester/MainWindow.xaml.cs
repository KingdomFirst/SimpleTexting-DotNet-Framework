using Newtonsoft.Json;
using SimpleTextingDotNet.v2;
using SimpleTextingDotNet.v2.Model.Object;
using SimpleTextingDotNet.v2.Model.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static SimpleTextingDotNet.Enum;

namespace SimpleTextingApiTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            var expansions = new List<string>();
            foreach ( var expansion in Enum.GetNames( typeof( Mode ) ) )
            {
                expansions.Add( expansion );
            }
            lbMode.ItemsSource = expansions;
        }

        /// <summary>
        /// Get an instance of api client.
        /// </summary>
        /// <returns></returns>
        private Client GetApiClient()
        {
            var ApiKey = tbApiKey.Text.Trim();
            var api = new Client( ApiKey );
            return api;
        }

        /// <summary>
        /// Handles the Click event of the Get Message Details button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GetMessageDetails_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var response = api.GetMessage( tbMessageId.Text );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        /// <summary>
        /// Handles the Click event of the Send Message button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SendMessage_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var mediaItemList = tbMediaItems.Text.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries ).Select( t => t.Trim() ).ToList();
                var response = api.SendMessage(
                    tbContactPhone.Text.Trim(),
                    tbText.Text.Trim(),
                    ( Mode ) lbMode.SelectedItem,
                    tbAccountPhone.Text.Trim(),
                    tbSubject.Text.Trim(),
                    tbFallbackText.Text.Trim(),
                    mediaItemList );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        /// <summary>
        /// Displays the Message information.
        /// </summary>
        private void DisplayMessageInfo( Object response )
        {
            var responseType = response.GetType();
            var hasData = false;
            if ( responseType == typeof( Message ) )
            {
                var message = ( Message ) response;
                if ( message != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( message, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            else if ( responseType == typeof( SendResponse ) )
            {
                var sendResponse = ( SendResponse ) response;
                if ( sendResponse != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( sendResponse, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            if ( !hasData )
            {
                tbResponse.Text = "Please check your API Key";
                tbResponse.Foreground = Brushes.Red;
                return;
            }
            tbResponse.Focus();
        }

        /// <summary>
        /// Displays the Message information.
        /// </summary>
        private void DisplayException( Exception exception )
        {
            var sb = new StringBuilder();
            sb.AppendLine( exception.Message );
            if ( exception.InnerException != null )
            {
                sb.AppendLine( exception.InnerException.Message );
            }
            tbResponse.Text = sb.ToString();
            tbResponse.Foreground = Brushes.Red;
            tbResponse.Focus();
        }
    }
}
