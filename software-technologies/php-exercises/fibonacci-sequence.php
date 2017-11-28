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
        $fibonacciSeq[]=1;
        $fibonacciSeq[]=1;
        $fi1=1;
        $fi2=1;

        for ($i=0; $i <$num-2 ; $i++) {
          $sum = $fi1+$fi2;
        $fibonacciSeq[]= $sum;
        $fi1 = $fi2;
        $fi2 =$sum;
        }

        echo join(" ",$fibonacciSeq);
      }
    ?>
</body>
</html>
