<?php

/**
 * When sending special characters (such as ã) through the Partner API, please ensure that they are
 * UTF-8 encoded. This code sample provides a handful of functions to help determine if your text is
 * properly encoded, as well as an example on how to perform the proper encoding.
 */

const UTF_8 = 'UTF-8';
const ISO_8859_1 = 'ISO-8859-1';
const ISO_8859_15 = 'ISO-8859-15';

const OPERABLE_ENCODINGS = [UTF_8, ISO_8859_1, ISO_8859_15];

/**
 * Attempts to detect the encoding of `text`, returning true if and only if the detected encoding
 * is one of the given $operable_encodings.
 */
function detectEncoding(string $text, array $operable_encodings = OPERABLE_ENCODINGS) {
	return mb_detect_encoding($text, $operable_encodings, true);
}

/**
 * Encodes the given $text in UTF-8.
 */
function encodeToUtf8($text) {
	return mb_convert_encoding($text, UTF_8, detectEncoding($text));
}

/**
 * Encodes the given $text in ISO_8859_1.
 */
function encodeToIso($text) {
	return mb_convert_encoding($text, ISO_8859_1, mb_detect_encoding($text, OPERABLE_ENCODINGS, true));
}


function assertEncoding($text, $expected_encoding) {
    return detectEncoding($text) == $expected_encoding ? 
        "Assertion successful! {$text} is encoded as {$expected_encoding}\n" 
        : "Assertion failed! {$text} is NOT encoded as {$expected_encoding}\n";
}

// Begin with UTF-8 encoded text
$utf8_text = 'São Paulo: Brazil';
echo assertEncoding($utf8_text, UTF_8);

// Encode it to ISO
$now_as_iso8859_1 = encodeToIso($utf8_text);
echo assertEncoding($now_as_iso8859_1, ISO_8859_1);
assert(detectEncoding($now_as_iso8859_1) == ISO_8859_1);

// Back to UTF-8
$back_to_utf8 = encodeToUtf8($now_as_iso8859_1);
echo assertEncoding($back_to_utf8, UTF_8);
