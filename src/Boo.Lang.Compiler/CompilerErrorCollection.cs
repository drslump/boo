﻿#region license
// Copyright (c) 2004, Rodrigo B. de Oliveira (rbo@acm.org)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Rodrigo B. de Oliveira nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler.Ast;

namespace Boo.Lang.Compiler
{
	public class CompilerErrorEventArgs : CancellableEventArgs
	{
		private readonly CompilerError _error;

		public CompilerErrorEventArgs(CompilerError error)
		{
			_error = error;
		}

		public CompilerError Error
		{
			get { return _error;  }
		}
	}

	/// <summary>
	/// Compiler errors.
	/// </summary>
	public class CompilerErrorCollection : List<CompilerError>
	{
		public event EventHandler<CompilerErrorEventArgs> Adding;

		public CompilerErrorCollection()
		{
		}

		override public List<CompilerError> Add(CompilerError error)
		{
			return OnAdding(error) ? base.Add(error) : this;
		}

		protected bool OnAdding(CompilerError error)
		{
			EventHandler<CompilerErrorEventArgs> adding = Adding;
			if (null == adding)
				return true;
			var args = new CompilerErrorEventArgs(error);
			adding(this, args);
			return !args.IsCancelled;
		}
		
		override public string ToString()
		{
			return ToString(false);
		}
		
		public string ToString(bool verbose)
		{
			var writer = new System.IO.StringWriter();
			foreach (var error in this)
				writer.WriteLine(error.ToString(verbose));
			return writer.ToString();
		}		
	}
}
