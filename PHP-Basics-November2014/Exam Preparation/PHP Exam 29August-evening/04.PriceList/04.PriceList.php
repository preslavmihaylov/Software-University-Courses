<?php

// $_GET['priceList'] = '<table class="priceListTable">  <tr>   <th>Product</th>    <th>Category</th>    <th>Price</th>   <th>Currency</th></tr><tr> <td>8GB DDR3L 1600 KINGSTON SODIMM</td><td>RAM</td><td>87.00</td>  <td>  USD</td></tr> <tr> <td>500GB Toshiba, SATA 6Gb/s, 7200rpm, 32MB</td> <td>HDD</td> <td>88.41</td> <td>BGN </td>
// </tr><tr><td>AMD A10-5800K X4 3.8GHz, 4MB Cache</td><td>CPU</td>   <td> 186.00</td> <td>BGN</td></tr> <tr> <td> SSD 2.5&quot;, 120GB, Corsair F120 LS, SATA3</td> <td> HDD</td> <td> 180.50</td> <td> BGN </td>  </tr>  <tr>     <td>ASRock B75M-GL R2.0</td><td>motherboard</td> <td>  47.55</td> <td>EUR</td>  </tr> <tr> <td>1TB Toshiba, SATA 6Gb/s, 7200rpm, 32MB</td> <td>HDD</td><td> 52.82 </td> <td>EUR</td></tr><tr><td>16GB Micro SDHC, A-Data, Class10</td><td>RAM
// </td><td>15.03</td><td>BGN</td></tr></table>';

// $priceList = htmlentities($_GET['priceList']);
$priceList = $_GET['priceList'];
// $priceList = preg_replace('/(.)(\&lt\;)(.)/', '$1<$3', $priceList);
// $priceList = preg_replace('/(.)(\&amp\;)(.)/', '$1&$3', $priceList);
// $priceList = preg_replace('/(.)(\&quot\;)(.)/', '$1"$3', $priceList);
preg_match_all('/\<td\>\s*([^<]+)\s*\<\/td\>/', $priceList, $result);

$data = new stdClass();

// var_dump($result);

for ($index = 0; $index < count($result[1]); $index+= 4) {
    $product = html_entity_decode(trim($result[1][$index]));
    $category = html_entity_decode(trim($result[1][$index + 1]));
    $price = html_entity_decode(trim($result[1][$index + 2]));
    $currency = html_entity_decode(trim($result[1][$index + 3]));

    if (!isset($data->$category)) {
        $data->$category = [];
        $data->{$category}[0] = new stdClass();
        $data->{$category}[0]->product = $product;
        $data->{$category}[0]->price = $price;
        $data->{$category}[0]->currency = $currency;
    } else {
        $data->{$category}[count($data->{$category})] = new stdClass();
        $data->{$category}[count($data->{$category}) - 1]->product = $product;
        $data->{$category}[count($data->{$category}) - 1]->price = $price;
        $data->{$category}[count($data->{$category}) - 1]->currency = $currency;
    }
}

foreach ($data as $key => $value) {
    usort($data->$key, function($a, $b) {
       if (strcmp($a->product, $b->product) > 0) {
           return strcmp($a->product, $b->product);
       } elseif (strcmp($a->product, $b->product) < 0) {
           strcmp($a->product, $b->product);
       } else {
           return 1;
       }
    });
}

$data = (array)$data;
ksort($data);

$data = (object)$data;


echo json_encode($data);

// {"CPU":[
//     {"product":"AMD A10-5800K X4 3.8GHz, 4MB Cache","price":"186.00","currency":"BGN"}
// ],
// "HDD":[
//     {"product":"1TB Toshiba, SATA 6Gb\/s, 7200rpm, 32MB","price":"52.82","currency":"EUR"},
//     {"product":"500GB Toshiba, SATA 6Gb\/s, 7200rpm, 32MB","price":"88.41","currency":"BGN"},
//     {"product":"SSD 2.5\", 120GB, Corsair F120 LS, SATA3","price":"180.50","currency":"BGN"}
// ],
// "RAM":[
//     {"product":"16GB Micro SDHC, A-Data, Class10","price":"15.03","currency":"BGN"},
//     {"product":"8GB DDR3L 1600 KINGSTON SODIMM","price":"87.00","currency":"USD"}
// ],
// "motherboard":[
//     {"product":"ASRock B75M-GL R2.0","price":"47.55","currency":"EUR"}
// ]}