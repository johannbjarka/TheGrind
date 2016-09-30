using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;

namespace UnityEngine.UI
{
	public class TextUniCode : Text
	{
		private bool disableDirty = false;
		private Regex regexp = new Regex( @"\\u(?<Value>[a-zA-Z0-9]{4})" );
		
		protected override void OnPopulateMesh( VertexHelper vbo )
		{
			string cache = this.text;
			
			disableDirty = true;
			
			this.text = this.Decode( this.text );
			
			base.OnPopulateMesh( vbo );
			
			this.text = cache;
			
			disableDirty = false;
		}
		
		private string Decode( string value )
		{
			return regexp.Replace( value, m => ( (char) int.Parse( m.Groups["Value"].Value, NumberStyles.HexNumber ) ).ToString() );
		}  
		
		public override void SetLayoutDirty()
		{
			if ( disableDirty ) {
				return;
			}
			
			base.SetLayoutDirty();
		}
		
		public override void SetVerticesDirty()
		{
			if ( disableDirty ) {
				return;
			}
			
			base.SetVerticesDirty();
		}
		
		public override void SetMaterialDirty()
		{
			if ( disableDirty ) {
				return;
			}
			
			base.SetMaterialDirty();
		}
	}
}