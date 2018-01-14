using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetNavigator
{
    public class SolutionNavigatorRoslyn : ISolutionNavigator
    {
        Dictionary<string, SyntaxTree> _syntaxTrees;
        Compilation _compilation;
        List<string> _sources;
        Workspace _workspace = new AdhocWorkspace();

        public SolutionNavigatorRoslyn()
        {
        }

        public List<string> GetSourceFiles()
        {
            return _sources;
        }

        public void Compile(string solutionPath)
        {
            var path = Path.GetDirectoryName(solutionPath);
            _sources = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories).ToList();
            _syntaxTrees = new Dictionary<string, SyntaxTree>();
            foreach (var file in _sources)
            {
                var sourceText = SourceText.From(File.ReadAllText(file));
                _syntaxTrees[file] = CSharpSyntaxTree.ParseText(sourceText, path: file);
            }

            var projectReferences = new PortableExecutableReference[] { };
            _compilation = CSharpCompilation.Create("temp", _syntaxTrees.ToArray().Select(t => t.Value));
        }

        public FileLocation GoToDefinition(FileLocation location)
        {
            var semanticModel = _compilation.GetSemanticModel(_syntaxTrees[location.FileName]);
            
            var symbol = SymbolFinder.FindSymbolAtPositionAsync(semanticModel, location.StartPosition, _workspace).Result;

            if (symbol != null)
            {
                var resultLocation = symbol.Locations[0];
                var result = new FileLocation()
                {
                    FileName = resultLocation.SourceTree.FilePath,
                    StartPosition = resultLocation.SourceSpan.Start,
                    EndPosition = resultLocation.SourceSpan.End
                };
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
