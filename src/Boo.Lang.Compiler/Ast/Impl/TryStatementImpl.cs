#region license
// Copyright (c) 2009 Rodrigo B. de Oliveira (rbo@acm.org)
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

//
// DO NOT EDIT THIS FILE!
//
// This file was generated automatically by astgen.boo.
//
namespace Boo.Lang.Compiler.Ast
{	
	using System.Collections;
	using System.Runtime.Serialization;
	
	[System.Serializable]
	public partial class TryStatement : Statement
	{
		protected Block _protectedBlock;

		protected ExceptionHandlerCollection _exceptionHandlers;

		protected Block _failureBlock;

		protected Block _ensureBlock;


		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		new public TryStatement CloneNode()
		{
			return (TryStatement)Clone();
		}
		
		/// <summary>
		/// <see cref="Node.CleanClone"/>
		/// </summary>
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		new public TryStatement CleanClone()
		{
			return (TryStatement)base.CleanClone();
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public NodeType NodeType
		{
			get { return NodeType.TryStatement; }
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public void Accept(IAstVisitor visitor)
		{
			visitor.OnTryStatement(this);
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public bool Matches(Node node)
		{	
			if (node == null) return false;
			if (NodeType != node.NodeType) return false;
			var other = ( TryStatement)node;
			if (!Node.Matches(_modifier, other._modifier)) return NoMatch("TryStatement._modifier");
			if (!Node.Matches(_protectedBlock, other._protectedBlock)) return NoMatch("TryStatement._protectedBlock");
			if (!Node.AllMatch(_exceptionHandlers, other._exceptionHandlers)) return NoMatch("TryStatement._exceptionHandlers");
			if (!Node.Matches(_failureBlock, other._failureBlock)) return NoMatch("TryStatement._failureBlock");
			if (!Node.Matches(_ensureBlock, other._ensureBlock)) return NoMatch("TryStatement._ensureBlock");
			return true;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}
			if (_modifier == existing)
			{
				this.Modifier = (StatementModifier)newNode;
				return true;
			}
			if (_protectedBlock == existing)
			{
				this.ProtectedBlock = (Block)newNode;
				return true;
			}
			if (_exceptionHandlers != null)
			{
				ExceptionHandler item = existing as ExceptionHandler;
				if (null != item)
				{
					ExceptionHandler newItem = (ExceptionHandler)newNode;
					if (_exceptionHandlers.Replace(item, newItem))
					{
						return true;
					}
				}
			}
			if (_failureBlock == existing)
			{
				this.FailureBlock = (Block)newNode;
				return true;
			}
			if (_ensureBlock == existing)
			{
				this.EnsureBlock = (Block)newNode;
				return true;
			}
			return false;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public object Clone()
		{
		
			TryStatement clone = new TryStatement();
			clone._lexicalInfo = _lexicalInfo;
			clone._endSourceLocation = _endSourceLocation;
			clone._documentation = _documentation;
			clone._isSynthetic = _isSynthetic;
			clone._entity = _entity;
			if (_annotations != null) clone._annotations = (Hashtable)_annotations.Clone();
			if (null != _modifier)
			{
				clone._modifier = _modifier.Clone() as StatementModifier;
				clone._modifier.InitializeParent(clone);
			}
			if (null != _protectedBlock)
			{
				clone._protectedBlock = _protectedBlock.Clone() as Block;
				clone._protectedBlock.InitializeParent(clone);
			}
			if (null != _exceptionHandlers)
			{
				clone._exceptionHandlers = _exceptionHandlers.Clone() as ExceptionHandlerCollection;
				clone._exceptionHandlers.InitializeParent(clone);
			}
			if (null != _failureBlock)
			{
				clone._failureBlock = _failureBlock.Clone() as Block;
				clone._failureBlock.InitializeParent(clone);
			}
			if (null != _ensureBlock)
			{
				clone._ensureBlock = _ensureBlock.Clone() as Block;
				clone._ensureBlock.InitializeParent(clone);
			}
			return clone;


		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override internal void ClearTypeSystemBindings()
		{
			_annotations = null;
			_entity = null;
			if (null != _modifier)
			{
				_modifier.ClearTypeSystemBindings();
			}
			if (null != _protectedBlock)
			{
				_protectedBlock.ClearTypeSystemBindings();
			}
			if (null != _exceptionHandlers)
			{
				_exceptionHandlers.ClearTypeSystemBindings();
			}
			if (null != _failureBlock)
			{
				_failureBlock.ClearTypeSystemBindings();
			}
			if (null != _ensureBlock)
			{
				_ensureBlock.ClearTypeSystemBindings();
			}

		}
	

		[System.Xml.Serialization.XmlElement]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public Block ProtectedBlock
		{
			
			get
			{ 
				if (_protectedBlock == null)
				{
					_protectedBlock = new Block();
					_protectedBlock.InitializeParent(this);
				}
				return _protectedBlock;
			}
			set
			{
				if (_protectedBlock != value)
				{
					_protectedBlock = value;
					if (null != _protectedBlock)
					{
						_protectedBlock.InitializeParent(this);
					}
				}
			}

		}
		

		[System.Xml.Serialization.XmlArray]
		[System.Xml.Serialization.XmlArrayItem(typeof(ExceptionHandler))]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public ExceptionHandlerCollection ExceptionHandlers
		{
			

			get { return _exceptionHandlers ?? (_exceptionHandlers = new ExceptionHandlerCollection(this)); }
			set
			{
				if (_exceptionHandlers != value)
				{
					_exceptionHandlers = value;
					if (null != _exceptionHandlers)
					{
						_exceptionHandlers.InitializeParent(this);
					}
				}
			}

		}
		

		[System.Xml.Serialization.XmlElement]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public Block FailureBlock
		{
			
			get { return _failureBlock; }
			set
			{
				if (_failureBlock != value)
				{
					_failureBlock = value;
					if (null != _failureBlock)
					{
						_failureBlock.InitializeParent(this);
					}
				}
			}

		}
		

		[System.Xml.Serialization.XmlElement]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public Block EnsureBlock
		{
			
			get { return _ensureBlock; }
			set
			{
				if (_ensureBlock != value)
				{
					_ensureBlock = value;
					if (null != _ensureBlock)
					{
						_ensureBlock.InitializeParent(this);
					}
				}
			}

		}
		

	}
}

