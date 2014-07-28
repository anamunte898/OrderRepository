

$patterns = "<h1 class=`"title`">", "<h1 class=`"price`">"

$liniiReturnate = Select-String -path .\*.txt -pattern $patterns

foreach ($linie in $liniiReturnate) {
    if ($linie.Line -match "<h1 class=`"title`">") { 
         $linie = $linie.Line.trim() -replace "<h1 class=`"title`">", ""
         $linie = $linie -replace "</h1>", ""
         $linie = $linie -replace "&#038;", " "
        $liniiFinale+= "insert into product(Name, Price) Values(`'" + $linie + "`',"
    }
     if ($linie.Line -match "<h1 class=`"price`">") { 
         $linie = $linie.Line.trim() -replace "<h1 class=`"price`">", ""
         $linie = $linie -replace "</h1>", ""
          $linie = $linie -replace "LEI", ""
        $liniiFinale+= "$linie);`n" 
    }
 }
Out-File -filepath .\Results.txt -inputobject $liniiFinale 


$liniiReturnate = Select-String -path .\*.txt -pattern $patterns
foreach ($linie in $liniiReturnate) {
    if ($linie.Line -match "<h1 class=`"title`">") { 
         $linie = $linie.Line.trim() -replace "<h1 class=`"title`">", ""
         $linie = $linie -replace "</h1>", ""
         $linie = $linie -replace "&#038;", " "
        $liniiFinaleFluent+= "Insert.IntoTable(`"Product`").Row(new { Name = `"" + $linie + "`","  
    }
     if ($linie.Line -match "<h1 class=`"price`">") { 
         $linie = $linie.Line.trim() -replace "<h1 class=`"price`">", ""
         $linie = $linie -replace "</h1>", ""
          $linie = $linie -replace " LEI", ""
        $liniiFinaleFluent+= "Price = `"" +$linie + "`"});`n" 
    }
 }

Out-File -filepath .\ResultsFluent.txt -inputobject $liniiFinaleFluent 


