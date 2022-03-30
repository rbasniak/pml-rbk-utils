using FastColoredTextBoxNS;
using rbkUtilities.RunMacro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rbkUtilities.Tester
{
    public partial class CodeEditor : Form
    {
        private SyntaxHighlightService _highlightService;

        public CodeEditor()
        {
            InitializeComponent();

            _highlightService = new SyntaxHighlightService(CodeInput);

            CodeInput.AutoIndentNeeded += new EventHandler<AutoIndentEventArgs>(_highlightService.ProcessAutoIdentation);

            CodeInput.BackColor = Color.FromArgb(0, Color.WhiteSmoke);
            CodeInput.IndentBackColor = Color.FromArgb(100, Color.Gainsboro);
            CodeInput.ForeColor = Color.FromArgb(200, Color.Black);

            CodeInput.Text = @"



pml reload form !!rbkRunMacro
show !!rbkRunMacro



return

import 'D:\Repositories\pessoal\rbkStruct\rbkStruct\bin\Debug\rbkStruct'
handle (1000,0)
endhandle

using namespace 'rbkPmlUtilities'

!struct = object rbkStruct()

q var !struct.get('null2')

return

import 'D:\Repositories\pessoal\rbkStruct\rbkStruct\bin\Debug\rbkStruct'
handle (1000,0)
endhandle

using namespace 'rbkPmlUtilities'

!start = Object datetime()
!native = array()
do !i from 1 to 2000
  !struct = object rbkStruct()
  do !j from 1 to 50
    !struct.set('PROPRIEDADE$!j', 'VALUE $!j')
  enddo
  !native.append(!struct)
enddo

do !i from 1 to 2000
  !struct = !native[!i]
  do !j from 1 to 50
    !struct.set('PROPRIEDADE$!j', 'NEW VALUE $!j')
  enddo
enddo

do !i from 1 to 2000
  !struct = !native[!i]
  do !j from 1 to 50
    !a = !struct.get('PROPRIEDADE$!j')
  enddo
enddo

!end = Object datetime()


!elapsed = (!end.minute() * 60 + !end.second()) - (!start.minute() * 60 + !start.second())

$P Took $!elapsed seconds to write and read 100.000 values in 2000 data structures


return



!start = Object datetime()
!native = array()
do !i from 1 to 2000
  !struct = object RBKSTRUCTNATIVE()
  do !j from 1 to 50
    !struct.set('PROPRIEDADE$!j', 'VALUE $!j')
  enddo
  !native.append(!struct)
enddo

do !i from 1 to 2000
  !struct = !native[!i]
  do !j from 1 to 50
    !struct.set('PROPRIEDADE$!j', 'NEW VALUE $!j')
  enddo
enddo

do !i from 1 to 2000
  !struct = !native[!i]
  do !j from 1 to 50
    !a = !struct.get('PROPRIEDADE$!j')
  enddo
enddo

!end = Object datetime()


!elapsed = (!end.minute() * 60 + !end.second()) - (!start.minute() * 60 + !start.second())

$P Took $!elapsed seconds to write and read 100.000 values in 2000 data structures

return
  !revMgr = object PMLPIPINGREVISIONMANAGER(!!ce)
  !revisions = !revMgr.getRevisionData()
q var !revisions[1].keys
q var !revisions[1].values
q var !revisions[2].values


return
alpha req clear

!sample1 = object RBKSTRUCT()
!sample1.set('boolean', true)
!sample1.set('string', 'This is my value')
!sample1.set('real', 19)

!element = /62_11_CI
!sample1.set('dbref', !element)

!numbers = array()
!numbers.append(1)
!numbers.append(2)
!numbers.append(3)
!numbers.append(4)
!sample1.set('numberArray', !numbers)

!strings = array()
!strings.append('A')
!strings.append('B')
!strings.append('C')
!strings.append('D')
!sample1.set('stringArray', !strings)

!bools = array()
!bools.append(true)
!bools.append(false)
!bools.append(false)
!bools.append(true)
!sample1.set('booleansArray', !bools)

!elements = array()
!elements.append(=805329448/1)
!elements.append(=16784/967)
!elements.append(=805330303/260419)
!sample1.set('elementsArray', !elements)

!sample2 = object RBKSTRUCT()
!sample2.set('value1', 65)
!sample2.set('value2', 5346)
!sample2.set('value3', 9873)

!sample1.set('struct', !sample2)

q var !sample1.keys
q var !sample1.values

$P
!lines = !sample1.toJson()

do !i from 1 to !lines.size()
  $P $!lines[$!i]
enddo


return

alpha req clear

!obj1 = object RBKSTRUCT()

!obj1.set('k1', 'My original K1 value')
!obj1.set('k2', 'K2 value')
!obj1.set('k1', 'My new K1 value')

!obj1.set('k3', 4)

!obj1.set('k4', 'KKKK')

!obj1.set('k5', false)
!obj1.set('k5', true)

!array = array()
!array.append(1)
!array.append(3)
!array.append(19)

!obj1.set('k6', !array)

!obj1.set('k7', !!ce.position)

!obj2 = object RBKSTRUCT()
!obj2.set('v1', 'value 1')
!obj2.set('v2', 'value 2')
!obj2.set('v3', 'value 3')

!obj1.set('k8', !obj2)

-- q var !obj1.keys
-- q var !obj1.values
-- !obj1.set('k8', 'v4', 'Yessssssssssss')

q var !obj1.get('k1')
q var !obj1.get('k2')
q var !obj1.get('k3')
q var !obj1.get('k4')
q var !obj1.get('k5')
q var !obj1.get('k6')
q var !obj1.get('k7')
q var !obj1.get('k8')

 q var !obj1.objectType()

return




var !pipes collect all PIPE with matchw (name of site, '/32*')

do !i from 1 to !pipes.size()
  !pipe = !pipes[!i]
  $m'D:\Repositories\iter\quality-checker\QualityChecker.Domain.Models\Auditings\Auditings\PipingSpecificationConsistency.pmlmac' $!pipe
enddo

return

show !!rbkPmlIpcServer

return

=402678633/5498
!revMgr = object PMLPIPINGREVISIONMANAGER(=402678633/5498)
!revMgr.copyRevisionDataFromZone()

return

-- =402670468/7112
-- pml rehash all
-- pml reload form !!PMLRevisionTool
-- pml reload object PMLPIPINGREVISIONMANAGER
show !!PMLRevisionTool

-- !revMgr = object !!PMLPIPINGREVISIONMANAGER(=402670468/7112)

return

ALPHA REQ CLEAR

$P ----------------------------------------------------------------------------------------------------------------
$P ELEMENT /REVLNK
$P ----------------------------------------------------------------------------------------------------------------

!!ce = /REVLNK
!desc1 = !!ce.description
!celref1 = !!ce.celref
!rvcon1 = !!ce.rvcon

$P DESC
q var !desc1
$P --------------------------------------------------------
$P CELREF
q var !celref1
$P --------------------------------------------------------
$P RVCON
q var !rvcon1
$P --------------------------------------------------------

$P
$P ----------------------------------------------------------------------------------------------------------------
$P ELEMENT /REVISS
$P ----------------------------------------------------------------------------------------------------------------

!!CE = /REVISS
!Rvnum   = !!ce.Rvnum
!Rvnpts = !!ce.Rvnpts
!Rviss = !!ce.Rviss
!Rvcanc = !!ce.Rvcanc
!RVUR = !!ce.RVURi
!Exfile = !!ce.Exfile
!Pvno = !!ce.Pvno
!Number = !!ce.Number
!RVFTYP = !!ce.RVFTYP
!Stahr = !!ce.Stahrf
!Relrev = !!ce.Relrev


$P RVNUM
q var !Rvnum
$P --------------------------------------------------------
$P RVNPTS
q var !Rvnpts
$P --------------------------------------------------------
$P RVISS
q var !Rviss
$P --------------------------------------------------------
$P RVCANC
q var !Rvcanc
$P --------------------------------------------------------
$P RVURI
q var !RVUR
$P --------------------------------------------------------
$P EXFILE
q var !Exfile
$P --------------------------------------------------------
$P PVNO
q var !Pvno
$P --------------------------------------------------------
$P NUMBER
q var !Number
$P --------------------------------------------------------
$P RVFTYP
q var !RVFTYP
$P --------------------------------------------------------
$P STAHR
q var !Stahr
$P --------------------------------------------------------
$PRELREV
q var !Relrev
$P --------------------------------------------------------



return



!name = !!CE.name
!textIndex = 1
Do !i from 1 to !!ce.members.size()
  !extra = ''
  !ref = !!ce.members[!i]
  if !ref.Type eq 'TEXT' then
      !newName = !name + '-PA$!textIndex'
      !textIndex = !textIndex + 1
  elseif !ref.Type eq 'SCOM' then
      !dn = !ref.para[0]
      !newName = !name + ':$!dn'
      var !params PARA OF $!ref
      !extra = 'PARA $!params'
  else
    !type = !ref.Type
    !newName = !name + '-$!type'
  endif

  $P OLD $!ref NAME $!newName $!extra
enddo














-- comment

define method .dsadas
  !!test.myfnc()
  asdasda
endmethod


define function .dsadas

endmethod


define object .dsadas
  do !i from 1 to !variable.size()  $* comments
    !this.do()
  enddo
endobject

setup form !!g2lobal sizeable
  if true then
    !a = 1
  else
    !b = 4 * !d4f
    !this.dasda()
  endif
exit

!variable.Do()
!variable = 1
!this.ddddd()

";
        }

        private void CodeInput_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            _highlightService?.ProcessSyntaxHighlight(sender, e);
        }
    }
}
