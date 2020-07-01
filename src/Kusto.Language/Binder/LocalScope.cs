﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Kusto.Language.Binding
{
    using Symbols;

    /// <summary>
    /// Models nested scoping for let variables and function parameters.
    /// </summary>
    internal class LocalScope
    {
        private readonly LocalScope _outerScope;
        private Dictionary<string, Symbol> _symbols;
        private LocalScope _sharedScope;

        private LocalScope(Dictionary<string, Symbol> symbols, LocalScope outerScope, LocalScope sharedScope)
        {
            _symbols = symbols;
            _outerScope = GetMinimalOuterScope(outerScope);
            _sharedScope = sharedScope;
        }

        private static LocalScope GetMinimalOuterScope(LocalScope outerScope)
        {
            while (outerScope != null 
                && outerScope._symbols == null 
                && outerScope._sharedScope == null)
            {
                outerScope = outerScope._outerScope;
            }

            return outerScope;
        }

        /// <summary>
        /// Create a new instance of a <see cref="LocalScope"/>
        /// </summary>
        /// <param name="outerScope">An optional outer scope.</param>
        public LocalScope(LocalScope outerScope = null)
            : this(null, outerScope, null)
        {
        }

        /// <summary>
        /// Returns true if the local scope constains a symbol with the given name.
        /// </summary>
        public bool ContainsSymbol(string name)
        {
            return (_symbols != null && _symbols.ContainsKey(name))
                || (_sharedScope != null && _sharedScope.ContainsSymbol(name));
        }

        /// <summary>
        /// Makes a copy of this <see cref="LocalScope"/>.
        /// </summary>
        public LocalScope Copy()
        {
            // if we have any non-shared symbols, then move them into shared chain of symbols that
            // can be shared w/o fear of modification (basically copy-on-fear-of-writing).
            if (_symbols != null && _symbols.Count > 0)
            {
                _sharedScope = new LocalScope(_symbols, null, _sharedScope);
                _symbols = null;
            }

            return new LocalScope(null, _outerScope, _sharedScope);
        }

        /// <summary>
        /// Add a <see cref="Symbol"/> to the <see cref="LocalScope"/>
        /// </summary>
        public bool AddSymbol(Symbol symbol)
        {
            if (symbol != null)
            {
                if (_symbols == null)
                {
                    _symbols = new Dictionary<string, Symbol>();
                }

                _symbols[symbol.Name] = symbol;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds a collection of <see cref="Symbol"/> to the <see cref="LocalScope"/>.
        /// </summary>
        public void AddSymbols(IEnumerable<Symbol> symbols)
        {
            foreach (var symbol in symbols)
            {
                AddSymbol(symbol);
            }
        }

        /// <summary>
        /// Gets all the matching symbols in the scope, and then from any outer scopes.
        /// </summary>
        public void GetSymbols(string name, SymbolMatch match, List<Symbol> symbols)
        {
            if (_symbols != null)
            {
                if (name != null)
                {
                    if (_symbols.TryGetValue(name, out var decl) && decl.Matches(name, match))
                    {
                        symbols.Add(decl);
                        return;
                    }
                }
                else
                {
                    foreach (var symbol in _symbols.Values)
                    {
                        if (symbol.Matches(name, match))
                        {
                            symbols.Add(symbol);
                        }
                    }
                }
            }

            if (_sharedScope != null)
            {
                _sharedScope.GetSymbols(name, match, symbols);
            }

            if (_outerScope != null)
            {
                _outerScope.GetSymbols(name, match, symbols);
            }
        }

        /// <summary>
        /// Gets all the matching symbols in the scope.
        /// </summary>
        public void GetSymbols(SymbolMatch match, List<Symbol> symbols)
        {
            GetSymbols(null, match, symbols);
        }
    }
}