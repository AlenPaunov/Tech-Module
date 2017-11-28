<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
      if (isset($_GET['num'])) {
        $num = intval($_GET['num']);
        $tribonacciSeq[]=1;
        $tribonacciSeq[]=1;
        $tribonacciSeq[]=2;
        $tri1=1;
        $tri2=1;
        $tri3=$tri1+$tri2;

        for ($i=0; $i <$num-3 ; $i++) {
          $sum = $tri1+$tri2+$tri3;
        $tribonacciSeq[]= $sum;
        $tri1 = $tri2;
        $tri2 =$tri3;
        $tri3=$sum;
        }

        echo join(" ",$tribonacciSeq);
      }
    ?>
</body>
</html>
